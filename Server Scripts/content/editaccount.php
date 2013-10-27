<?php 
    // This if statement checks to determine whether the edit form has been submitted 
    // If it has, then the account updating code is run, otherwise the form is displayed 
    if(!empty($_POST)) 
    { 
        // Make sure the user entered a valid E-Mail address 
        if(!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) 
        { 
            die("Invalid E-Mail Address"); 
        } 
         
        // If the user is changing their E-Mail address, we need to make sure that 
        // the new value does not conflict with a value that is already in the system. 
        // If the user is not changing their E-Mail address this check is not needed. 
        if($_POST['email'] != $_SESSION['user']['email']) 
        { 
            // Define our SQL query 
            $query = " 
                SELECT 
                    1 
                FROM users 
                WHERE 
                    email = :email 
            "; 
             
            // Define our query parameter values 
            $query_params = array( 
                ':email' => $_POST['email'] 
            ); 
             
            try 
            { 
                // Execute the query 
                $stmt = $db->prepare($query); 
                $result = $stmt->execute($query_params); 
            } 
            catch(PDOException $ex) 
            { 
                // Note: On a production website, you should not output $ex->getMessage(). 
                // It may provide an attacker with helpful information about your code.  
                die("Failed to run query: " . $ex->getMessage()); 
            } 
             
            // Retrieve results (if any) 
            $row = $stmt->fetch(); 
            if($row) 
            { 
                die("This E-Mail address is already in use"); 
            } 
        } 
         
        // If the user entered a new password, we need to hash it and generate a fresh salt 
        // for good measure. 
        if(!empty($_POST['password'])) 
        { 
            $salt = dechex(mt_rand(0, 2147483647)) . dechex(mt_rand(0, 2147483647)); 
            $password = hash('sha256', $_POST['password'] . $salt); 
            for($round = 0; $round < 65536; $round++) 
            { 
                $password = hash('sha256', $password . $salt); 
            } 
        } 
        else 
        { 
            // If the user did not enter a new password we will not update their old one. 
            $password = null; 
            $salt = null; 
        } 
         
        // Initial query parameter values 
        $query_params = array( 
            ':email' => $_POST['email'], 
            ':user_id' => $_SESSION['user']['id'], 
            ':display_name' => $_POST['displayname'], 
            ':online_status' => $_POST['onlinestatus'],
        ); 
         
        // If the user is changing their password, then we need parameter values 
        // for the new password hash and salt too. 
        if($password !== null) 
        { 
            $query_params[':password'] = $password; 
            $query_params[':salt'] = $salt; 
        } 
         
        // Note how this is only first half of the necessary update query.  We will dynamically 
        // construct the rest of it depending on whether or not the user is changing 
        // their password. 
        $query = " 
            UPDATE users 
            SET 
                email = :email 
        "; 
         
        // If the user is changing their password, then we extend the SQL query 
        // to include the password and salt columns and parameter tokens too. 
        if($password !== null) 
        { 
            $query .= " 
                , password = :password 
                , salt = :salt 
            "; 
        } 
        // If the user is changing their display name, we extend the SQL Query
        // to include the new display column
        if ($display !== null)
        {
            $query .= " 
                , displayname = :display_name 
            "; 
        }
        // If the user is changing their online status, we extend the SQL Query
        // to include the new display column
        if ($status !== null)
        {
            $query .= " 
                , onlinestatus = :online_status 
            "; 
        }
        // Finally we finish the update query by specifying that we only wish 
        // to update the one record with for the current user. 
        $query .= " 
            WHERE 
                id = :user_id 
        "; 
         
        try 
        { 
            // Execute the query 
            $stmt = $db->prepare($query); 
            $result = $stmt->execute($query_params); 
        } 
        catch(PDOException $ex) 
        { 
            // Note: On a production website, you should not output $ex->getMessage(). 
            // It may provide an attacker with helpful information about your code.  
            die("Failed to run query: " . $ex->getMessage()); 
        } 
         
        // Now that the user's E-Mail address has changed, the data stored in the $_SESSION 
        // array is stale; we need to update it so that it is accurate. 
        $_SESSION['user']['email'] = $_POST['email']; 
         
        // This redirects the user back to the members-only page after they register 
        header("Location: tep.php?p=editaccount"); 
         
        // Calling die or exit after performing a redirect using the header function 
        // is critical.  The rest of your PHP script will continue to execute and 
        // will be sent to the user if you do not die or exit. 
        die("Redirecting to tep.php?p=editaccount"); 
    } 
     
?> 
<h1><img src="img/icons/dashboard.png" alt="" /> Edit Your Information
</h1>
<div class="cb"></div>

<div class="bloc">
    <div class="title">Account Information</div>
    <div class="content">   
<form action="tep.php?p=editaccount" method="post"> 
    Username:<br /> 
    <b><?php echo htmlentities($_SESSION['user']['username'], ENT_QUOTES, 'UTF-8'); ?></b> 
    <br /><br /> 
    E-Mail Address:<br /> 
    <input type="text" name="email" value="<?php echo htmlentities($_SESSION['user']['email'], ENT_QUOTES, 'UTF-8'); ?>" /> 
    <br /><br /> 
    Password:<br /> 
    <input type="password" name="password" value="" /><br /> 
    <i>(leave blank if you do not want to change your password)</i> 
    <br /><br />
    Display Name:<br />
    <input type="text" name="displayname" value="<?php echo htmlentities($_SESSION['user']['displayname'], ENT_QUOTES, 'UTF-8'); ?>" /> 
    <br /><br />
    Online Status:<br />
    <input type="checkbox" name="customstatus">Use Custom Status<br />
    <input type="text" name="customstatustxt" value="<?php echo htmlentities($_SESSION['user']['onlinestatus'], ENT_QUOTES, 'UTF-8'); ?>" /><br /><br />
    <select name="onlinestatus">
    <option>Availble</option>
    <option>Away</option>
    <option>Busy</option>
    <option>Invisibile</option>
    <option>Offline</option>
    </select><br /><br />
    <input type="submit" value="Update Account" /> 
</form>
    </div>
</div>