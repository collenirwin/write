<!DOCTYPE html>
<html>
<head>
    <title>Write</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/msg.css" />
    <script src="../js/jquery-2.1.3.min.js"></script>
    <script src="../js/utils.js"></script>
    <script src="../js/msg.js"></script>
    <script src="../js/write.js"></script>
</head>
<body>
    <?php include "../php/msg.php"; ?>

    <div id="wrapper">
        <div id="content">
            <form id="frmWrite">

                <h3 class="writeH3">Title</h3>
                <input type="text" id="txtTitle" class="ol writeText writeInputGen" placeholder="A name for your post" maxlength="500" />
                <br />

                <h3 class="writeH3">Body</h3>
                <textarea id="txtBody" class="ol writeText writeInputGen" placeholder="Write whatever you like" maxlength="20000"></textarea>
                <br />

                <div id="chkEditContainer">
                    <label><input type="checkbox" id="chkEdit" class="ol" />Anyone can edit this</label>
                </div>
                <br />

                <div id="tagControls">
                    <input type="text" id="txtTag" class="ol writeInputGen" placeholder="What's this post about?" maxlength="20" />
                    <input type="button" id="btnTag" class="ol btn" value="Tag &#8594" />
                    <div id="tagError"></div>
                </div>
                
                <div id="tagsContainer">
                    <h3 class="writeH3">
                        Tags
                        <input type="button" id="btnRemoveAllTags" class="tagX" onclick="msgDeleteTag.show();" value="X" />
                    </h3>
                    <div id="tags"></div>
                </div>

                <input type="button" id="btnPostWrite" class="ol btn" value="Post" />
            </form>
        </div>
    </div>
</body>
</html>