<!DOCTYPE html>
<html>
<head>
    <title>Write - PostTitleHere</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>
    <div id="connError">
        <?php
            include "../php/conn.php";
            include "../php/tags.php";
            
            $post_ID = "";
            $title   = "";
            $body    = "";
            $edit    = 0;
            $tags    = array();
			
			// Mono?
			// Django?
			
            try {
                if (!$con) {
                    echo "Couldn't connect to our database. Please try again later.";
                } else {
                    $post_ID = $_GET["post_id"]; // TODO: add validaiton
                    
                    $stmt = $con->prepare("SELECT post_title, post_body, post_edit FROM post WHERE post_id = ?");
                    $stmt->bind_param("i", $post_ID);
                    $stmt->execute();
                    $stmt->bind_result($t, $b, $e);
                    while ($stmt->fetch()) {
                        $title = htmlspecialchars($t);
                        $body  = htmlspecialchars($b);
                        $edit  = $e; // never echoed
                    }
                    
                    $stmt->free_result();
                    $stmt->close();
                    
                    $tags = getTagsDB($con, $post_ID);
                }
            } catch(Exception $e) {
                echo "Something's gone wrong! Please try again later.";
            }
            
            mysqli_close($con);
        ?>
    </div>
    
    <div id="wrapper">
        <div id="content">
            <div id="postTitle">
                <?php
                    echo $title;
                ?>
            </div>
            <div id="postBody">
                <?php
                    echo $body;
                ?>
            </div>
            <div id="postTags">
                <h3 class="writeH3">Tags</h3>
                <div id="tags">
                    <?php
                        foreach ($tags as $tag) {
                            echo "<span class='tag'>" . $tag . "</span>";
                        }
                    ?>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
