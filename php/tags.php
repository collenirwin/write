<?php
    function getTags($tagString) {
        $tagArray = explode("|", $tagString); // Populate array
        
        $tagArray = array_merge(array_diff($tagArray, array(""))); // Get rid of empty tags
        
        for ($x = 0; $x < count($tagArray); $x++) {
            if (strlen($tagArray[x]) > 255) { // Too long
                $tagArray[x] = substr($tagArray[x], 0, 255); // Lop off excess
            }
            
            $tagArray[x] = htmlspecialchars($tagArray);
        }
        
        return $tagArray;
    }
    
    function getTagsDB($connection, $postID) {  
        $result = mysqli_query($connection, 
            "SELECT tag.tag_text AS tagtext FROM tag_link INNER JOIN tag ON tag.tag_id = tag_link.tag_id WHERE post_id = $postID");
            
        $tagArray = array();
        
        if ($result) {
            while ($row = mysqli_fetch_assoc($result)) {
                array_push($tagArray, htmlspecialchars($row["tagtext"]));
            }
        }
        
        
        return $tagArray;
    }
?>