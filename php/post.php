<?php 
    include "conn.php";
    include "tags.php";
    
    if (!$con) { // Can't connect to db
        echo "Couldn't connect to our database. Please try again later.";
    } else { // Connection good
        try {
            $title   = $_POST["title"];
            $body    = $_POST["body"];
            $edit    = $_POST["edit"];
            $last_ID = -1;
            
            $tags = getTags($_POST["tags"]);
            
            // Post table
            $postQuery = "INSERT into post (post_title, post_body, post_edit) VALUES (?, ?, ?)";
            $stmt = $con->prepare($postQuery);
            $stmt->bind_param("ssi", $title, $body, $edit);
            $stmt->execute();
            $last_ID = $con->insert_id; // ID of the new row
            $stmt->close();
            
            // Tag table
            $tagQuery = "INSERT into tag (tag_text) VALUES (?)";
            $stmt = $con->prepare($tagQuery);
            
            // TagLink table
            $linkQuery = "INSERT into tag_link (tag_id, post_id) VALUES (?, ?)";
            $linkStmt = $con->prepare($linkQuery);
            
            for ($x = 0; $x < count($tags); $x++) {
                
                $stmt->bind_param("s", $tags[x]);
                $stmt->execute();
                $last_tag_ID = $con->insert_id;
                
                $linkStmt->bind_param("ii", $last_tag_ID, $last_ID);
                $linkStmt->execute();
            }
            
            $stmt->close();
            $linkStmt->close();
            
            echo $last_ID;
            
        } catch(Exception $e) {
            echo "Something's gone wrong. Please try again later.";
        }
    }
    
    $con->close();
?>