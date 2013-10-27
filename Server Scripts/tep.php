<?php 

    // First we execute our common code to connection to the database and start the session 
    require("common.php"); 
     
    // At the top of the page we check to see whether the user is logged in or not 
    if(empty($_SESSION['user'])) 
    { 
        header("Location: login.php"); 
        die("Redirecting to login.php"); 
    } 
    $progquery = "SELECT * FROM proginfo"; 
    try 
    { 
        // These two statements run the query against your database table. 
        $progstmt = $db->prepare($progquery); 
        $progstmt->execute(); 
    } 
    catch(PDOException $ex) 
    { 
        // Note: On a production website, you should not output $ex->getMessage(). 
        // It may provide an attacker with helpful information about your code.  
        die("Failed to run query: " . $ex->getMessage()); 
    } 
         
    // Finally, we can retrieve all of the found rows into an array using fetchAll 
    $progrows = $progstmt->fetchAll(); 
     foreach($progrows as $progrow):
     $curvers = $progrow['currentversion'];
     $updlnk = $progrow['updateurl'];
     $frndlynm = $progrow['friendlyvers'];
     endforeach;
    // Everything below this point in the file is secured by the login system 
     
    // We can display the user's username to them by reading it from the session array.  Remember that because 
    // a username is user submitted content we must use htmlentities on it before displaying it to the user. 
/**
 * This page generate HTML Version of the page in the html directory
 * If you are looking for specific content please look at the "content" directory
 */
$firstVisit = false; 
define('WEBROOT',trim(dirname($_SERVER['PHP_SELF']),'/')); 
if(!isset($_GET['p']) || !preg_match('/^[a-z]+$/',$_GET['p'])){ $_GET['p'] = 'index';  $firstVisit = true;  }
if(!file_exists('content/'.$_GET['p'].'.php'))  $_GET['p'] = 'index'; 
$pages = array(
    'availablehosts' => 'Verified Hosts',
    'unverifiedhosts' => 'Unverified Hosts'
    //'notif' => 'Notifications',
);
ob_start(); 
?><!DOCTYPE html>
<html>
    <head>
        <title>The Elite Patch</title>
                <script type="text/javascript">
            function setLogin(user) {
                return window.external.setuser(user);
            }
            function CheckLogin() {
                return window.external.checklogins();
            }
            function DoPatch(edit) {
                return window.external.PatchHost(edit);
            }
            function DoUserLink(user) {
                var usr = "http://theelitepatch.com/user/" + user;
                return window.external.OpenUrl(usr);
            }
            function DoRemove(edit) {
                return window.external.RemoveHost(edit);
            }
            function DoVisitSite(sitename) {
                var site = "http://" + sitename;
                return window.external.VisitSite(site);
            }
            function DoVersionLink(vers) {
                var verlnk = "http://theelitepatch.com/host/" + vers;
                return window.external.VersSite(verlnk);
            }
            function DoVerifiedLink(verif) {
                var veriflnk = "http://theelitepatch.com/verification/" + verif;
                return window.external.VerifSite(veriflnk);
            }
            function GetLoggedInUser() {
                return window.external.LoggedInUser();
            }
            function DoLogout() {
                return window.external.logout();
            }
            function DoUpdateCheck() {
                return window.external.programversion();        
            }
            function SendUpdNote(updateurl) {
                return window.external.update(updateurl);
            }
            function SetFriendlyName(name) {
                return window.external.setFriendlyVersion(name);
            }
          </script>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        
        
        <!-- Main stylesheed  (EDIT THIS ONE) -->
        <link rel="stylesheet" href="css/style.css" />
        
        <!-- jQuery AND jQueryUI -->
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js"></script>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js"></script>
        
        <!-- jQuery Cookie - https://github.com/carhartl/jquery-cookie -->
        <script type="text/javascript" src="js/cookie/jquery.cookie.js"></script>
        
        <!-- jWysiwyg - https://github.com/akzhan/jwysiwyg/ -->
        <link rel="stylesheet" href="js/jwysiwyg/jquery.wysiwyg.old-school.css" />
        <script type="text/javascript" src="js/jwysiwyg/jquery.wysiwyg.js"></script>
        
        
        <!-- Tooltipsy - http://tooltipsy.com/ -->
        <script type="text/javascript" src="js/tooltipsy.min.js"></script>
        
        <!-- iPhone checkboxes - http://awardwinningfjords.com/2009/06/16/iphone-style-checkboxes.html -->
        <script type="text/javascript" src="js/iphone-style-checkboxes.js"></script>
        <script type="text/javascript" src="js/excanvas.js"></script>
        
        <!-- Load zoombox (lightbox effect) - http://www.grafikart.fr/zoombox -->
        <script type="text/javascript" src="js/zoombox/zoombox.js"></script>
        
        <!-- Charts - http://www.filamentgroup.com/lab/update_to_jquery_visualize_accessible_charts_with_html5_from_designing_with/ -->
        <script type="text/javascript" src="js/visualize.jQuery.js"></script>
        
        <!-- Uniform - http://uniformjs.com/ -->
        <script type="text/javascript" src="js/jquery.uniform.js"></script>
        
        
        <!-- Main Javascript that do the magic part (EDIT THIS ONE) -->
        <script type="text/javascript" src="js/main.js"></script>
        <?php
        /***/
        ?>
    </head>
    <body>
        <?php $sessuser = htmlentities($_SESSION['user']['displayname'], ENT_QUOTES, 'UTF-8'); ?>
        <script type="text/javascript">
            var php_var = "<?php echo $sessuser; ?>";
            if (CheckLogin()) { setLogin(php_var); }</script>
        <script type="text/javascript">
        var php_var = "<?php echo $curvers; ?>";
        var upd_url_php = "<?php echo $updlnk; ?>";
        if (DoUpdateCheck() < php_var)
        {
            SendUpdNote(upd_url_php);
        }
        var php_frnd_name = "<?php echo $frndlynm; ?>";
        SetFriendlyName(php_frnd_name);
        </script>
        <!--              
                HEAD
                        --> 
        <div id="head">
            <div class="left">
                Welcome,
                <script type="text/javascript"> if(CheckLogin()){ document.write(GetLoggedInUser());} else {var php_var="<?php echo $sessuser;?>"; document.write(php_var);}</script>
            </div>
            <div class="right">
                <a href="logout.php" onclick="DoLogout();">Logout</a>
            </div>
        </div>
                
                
        <!--            
                SIDEBAR
                         --> 
        <div id="sidebar">
            <ul>
                <li>
                    <a href="tep.php">
                        <img src="img/icons/menu/home.png" alt="" />
                        Dashboard
                    </a>
                </li>
                <li<?php if(!$firstVisit): ?> class="current hover"<?php endif; ?>><a href="#"><img src="img/icons/menu/list.png" alt="" /> Hosts Edits</a>
                    <ul>
                        <?php foreach($pages as $k=>$v): ?>
                        <li<?php if($k==$_GET['p']): ?> class="current"<?php endif; ?>><a href="tep.php?p=<?php echo $k; ?>"><?php echo $v; ?></a></li>
                        <?php endforeach; ?>
                    </ul>
                </li>
                <li><a href="tep.php?p=memberlist">
                    <img src="img/icons/menu/users.png" alt="" />
                    Memberlist
                    </a>
                </li>
                <li><a href="tep.php?p=editaccount">
                    <img src="img/icons/menu/user.png" alt="" />
                    Edit Account
                    </a>
                </li>
                <li><a href="tep.php?p=inbox">
                    <img src="img/icons/menu/comment.png" alt="" />
                    Messages
                    </a>
                </li>
            </ul>
        <a href="#collapse" id="menucollapse">&#9664; Collapse sidebar</a>
    </div>
                
                
                
                
        <!--            
              CONTENT 
                        --> 
        <div id="content" class="white">
            <?php if($_GET['p'] == 'full'): ?>
                <?php foreach($pages as $k=>$v): ?>
                    <?php require('content/'.$k.'.php'); ?>
                <?php endforeach; ?>
            <?php else: ?>
                <?php require('content/'.$_GET['p'].'.php'); ?>
            <?php endif; ?>
        </div>
        
        
    </body>
</html>
<?php
$content = ob_get_clean();
echo $content;
?>