<?php 
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
    $query = "SELECT * FROM `pm` WHERE `to`='".htmlentities($_SESSION['user']['id'], ENT_QUOTES, 'UTF-8')."'"; 
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
<h1><img src="img/icons/posts.png" alt="" /> Messages</h1>
<div class="notif tip">
                    Please note that the Messages Feature is currently still under development.
                    <a href="#" class="close"></a>
                </div>
<div class="bloc">
    <div class="title">
        Inbox
    </div>
    <div class="content">
        <table>
            <thead>
                <tr>
                    <th>From</th>
                    <th>Subject</th>
                    <th>Last Message Received</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach($rows as $row): ?> 
                    <tr> 
                        <?php
                            $query2 = "SELECT * FROM `users` WHERE `id`='".$row['from']."'";
                            try 
                            { 
                                // These two statements run the query against your database table. 
                                $stmt2 = $db->prepare($query2); 
                                $stmt2->execute(); 
                            } 
                            catch(PDOException $ex) 
                            { 
                                // Note: On a production website, you should not output $ex->getMessage(). 
                                // It may provide an attacker with helpful information about your code.  
                                die("Failed to run query: " . $ex->getMessage()); 
                            } 
                                 
                            // Finally, we can retrieve all of the found rows into an array using fetchAll 
                            $rows2 = $stmt2->fetchAll(); 
                        foreach($rows2 as $row2): ?> 
                        <td><?php echo $row2['displayname']; ?></td>
                        <?php endforeach; ?> 
                        <td><a href="tep.php?p=message&id=<?php echo $row['id']; ?>"><?php echo htmlentities($row['subject'], ENT_QUOTES, 'UTF-8'); ?></a></td> 
                        <td><?php echo htmlentities($row['lastmsgdate'], ENT_QUOTES, 'UTF-8'); ?></td>
                    </tr> 
                <?php endforeach; ?> 
            </tbody>
        </table>
    </div>
</div>