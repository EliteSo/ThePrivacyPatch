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
    $alertquery = "SELECT * FROM alerts WHERE `user`='".htmlentities($_SESSION['user']['id'], ENT_QUOTES, 'UTF-8')."' OR `user`='0' AND `displayed`='0'"; 
    try 
    { 
        // These two statements run the query against your database table. 
        $stmtalert = $db->prepare($alertquery); 
        $stmtalert->execute(); 
    } 
    catch(PDOException $ex) 
    { 
        // Note: On a production website, you should not output $ex->getMessage(). 
        // It may provide an attacker with helpful information about your code.  
        die("Failed to run query: " . $ex->getMessage()); 
    } 
         
    // Finally, we can retrieve all of the found rows into an array using fetchAll 
    $alertrows = $stmtalert->fetchAll();
    $changelogquery = "SELECT * FROM changelog ORDER BY `date` DESC"; 
    try 
    { 
        // These two statements run the query against your database table. 
        $stmtchangelog= $db->prepare($changelogquery); 
        $stmtchangelog->execute(); 
    } 
    catch(PDOException $ex) 
    { 
        // Note: On a production website, you should not output $ex->getMessage(). 
        // It may provide an attacker with helpful information about your code.  
        die("Failed to run query: " . $ex->getMessage()); 
    } 
         
    // Finally, we can retrieve all of the found rows into an array using fetchAll 
    $changelogrows = $stmtchangelog->fetchAll(); 
?> 
<h1><img src="img/icons/dashboard.png" alt="" /> Dashboard
</h1>
<?php foreach($alertrows as $alertrow): ?>
                <div class="notif success bloc">
                    <?php echo $alertrow['message']; ?>
                    <a href="#" class="close">x</a>
                </div>
                <?php endforeach; ?> 
<div class="cb"></div>

<div class="bloc">
                   <!-- <div class="notif tip">
                    No password needed just submit the form
                    <a href="#" class="close"></a>
                </div>-->
    <div class="title">What's new</div>
    <div class="content">   
        <?php foreach($changelogrows as $changelogrow): ?>
        <h5><?php echo $changelogrow['date']; ?></h5>
         <ul>
             <?php echo $changelogrow['items']; ?>
        </ul>
        <?php endforeach; ?> 
    </div>
</div>