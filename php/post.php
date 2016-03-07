<?php 
    include "conn.php";
    include "tags.php";
    
    if (!$con) { // Can't connect to db
        echo "Couldn't connect to our database. Please try again later.";
    } else { // Connection good
        try {
            $title   = mysqli_real_escape_string($con, $_POST["title"]);
            $body    = mysqli_real_escape_string($con, $_POST["body"]);
            $edit    = mysqli_real_escape_string($con, $_POST["edit"]);
            $last_ID = -1;
            
            $tags = getTags($_POST["tags"]);
            
            mysqli_query($con, // Post table
                "INSERT into $postTable (post_title, post_body, post_edit) VALUES ('$title', '$body', $edit)");
                
            $last_ID = mysqli_insert_id($con); // ID of the new row
            
            for ($x = 0; $x < count($tags); $x++) {
                mysqli_query($con, // Tag table
                    "INSERT into $tagTable (tag_text) VALUES ('" . mysqli_real_escape_string($tags[x]) . "')");
                
                $last_tag_ID = mysqli_insert_id($con);
                 
                mysqli_query($con, // Tag/post link table
                    "INSERT into $tagLinkTable (tag_id, post_id) VALUES ($last_tag_ID, $last_ID)");
            }
            
            echo $last_ID;
            
        } catch(Exception $e) {
            echo "Something's gone wrong. Please try again later.";
        }
    }
    
    mysqli_close($con);
?>