<?php 

    // First we execute our common code to connection to the database and start the session 
    require("common.php"); 
     
    // At the top of the page we check to see whether the user is logged in or not 
    if(empty($_SESSION['user'])) 
    { 
        // If they are not, we redirect them to the login page. 
        header("Location: login.php"); 
         
        // Remember that this die statement is absolutely critical.  Without it, 
        // people can view your members-only content without logging in. 
        die("Redirecting to login.php"); 
    } 
     
    // Everything below this point in the file is secured by the login system 
     
    // We can retrieve a list of members from the database using a SELECT query. 
    // In this case we do not have a WHERE clause because we want to select all 
    // of the rows from the database table. 
    $query = "SELECT * FROM hosts WHERE `verified`='Yes'"; 
     
    try 
    { 
        // These two statements run the query against your database table. 
        $stmt = $db->prepare($query); 
        $stmt->execute(); 
    } 
    catch(PDOException $ex) 
    { 
        // Note: On a production website, you should not output $ex->getMessage(). 
        // It may provide an attacker with helpful information about your code.  
        die("Failed to run query: " . $ex->getMessage()); 
    } 
         
    // Finally, we can retrieve all of the found rows into an array using fetchAll 
    $rows = $stmt->fetchAll(); 
?> 
<h1><img src="img/icons/posts.png" alt="" /> Table</h1>
<div class="bloc">
    <div class="title">
        Table Content
    </div>
    <div class="content">
        <table>
            <thead>
                <tr>
                    <th>Site</th>
                    <th>Author</th>
                    <th>Version</th>
                    <th>Verified</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach($rows as $row): ?> 
                    <tr> 
                        <td><a href="<?php echo htmlentities($row['siteurl'], ENT_QUOTES, 'UTF-8'); ?>"><?php echo htmlentities($row['sitename'], ENT_QUOTES, 'UTF-8'); ?></a></td>
                        <td><a href="#"><?php echo htmlentities($row['author'], ENT_QUOTES, 'UTF-8'); ?></a></td> 
                        <td><?php echo htmlentities($row['version'], ENT_QUOTES, 'UTF-8'); ?></td>
                        <td><?php echo htmlentities($row['verified'], ENT_QUOTES, 'UTF-8'); ?></td> 
                        <td class="actions"><input type="button" value="Install" onclick="DoPatch('<?php echo $row["hoststring"]; ?>')" /><input type="button" value="Remove" onclick="DoRemove('<?php echo $row["hoststring"]; ?>')" />
                    </td> 
                    </tr> 
                <?php endforeach; ?> 
            </tbody>
        </table>
    </div>
</div>