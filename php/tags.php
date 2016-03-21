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
    
    function getTagsDB($mysqli, $postID) {
        $result = "";
        
        $query = "SELECT tag.tag_text FROM tag_link INNER JOIN tag ON tag.tag_id = tag_link.tag_id WHERE post_id = ?";
        $stmt = $mysqli->prepare($query);
        $stmt->bind_param("i", $postID);
        $stmt->execute();
        $stmt->bind_result($result);
        
        $tagArray = array();
        
        if ($stmt->num_rows > 0) {
            while ($stmt->fetch()) {
                array_push($tagArray, htmlspecialchars($result));
            }
        }
        
        $stmt->free_result();
        $stmt->close();
        
        return $tagArray;
    }
?>
