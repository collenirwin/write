<!DOCTYPE html>
<html>
<head>
    <title>Write - PostTitleHere</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>
    <div id="wrapper">
        <div id="content">
            <div id="title">
                <?php
                echo $_POST["title"];
                ?>
            </div>
            <div id="body">
                <?php
                echo $_POST["body"];
                ?>
            </div>
        </div>
    </div>
</body>
</html>