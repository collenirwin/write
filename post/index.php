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
        
            try {
                if (!$con) {
                    echo "Couldn't connect to our database. Please try again later.";
                } else {
                    $post_ID = mysqli_real_escape_string($con, $_GET["post_id"]);
                    $post_all = mysqli_fetch_assoc(mysqli_query($con, "SELECT * FROM $postTable WHERE post_id = $post_ID"));
                    
                    $title = $post_all["post_title"];
                    $body  = $post_all["post_body"];
                    $edit  = $post_all["post_edit"];
                    
                    $tags = getTagsDB($con, $post_ID);
                }
            } catch(Exception $e) {
                echo "Something's gone wrong! Please try again later.";
            }
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