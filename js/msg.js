// msg.js
// author: Collen Irwin
// requires: jQuery, #msg div, #msgTitle div, #msgBody div, #msgFoot div, #msgOver div
// desc: basic messagebox class, alert replacer

Msg = function() {

    // Vars v

    var msg = document.getElementById("msg"),
        msgTitle = document.getElementById("msgTitle"),
        msgBody = document.getElementById("msgBody"),
        msgFoot = document.getElementById("msgFoot"),
        msgOver = document.getElementById("msgOver"),
        msgX    = document.getElementById("msgX");

    var self = this; // Hack needed to avoid losing 'this' somehow (really, javascript?)

    // Main Methods v

    this.init = function(title, body, buttons) {
        $(msgTitle).append(title);
        $(msgBody).html(body);
        $(msgFoot).html(buttons); // buttons should have .msgButton class
    }

    this.show = function(buttons) { 
        

        self.center();
        $(msgOver).fadeIn("fast");
        $(msg).fadeIn("fast");
    }

    this.close = function() {
        $(msg).fadeOut("fast");
        $(msgOver).fadeOut("fast");
    }

    this.center = function() { // Center msgbox in window
        msg.style.top = (($(window).height() / 2) - ($(msg).height() / 2)).toString() + "px";
        msg.style.left = (($(window).width() / 2) - ($(msg).width() / 2)).toString() + "px";
    }

    // Events v

    $(window).on("resize", function() {
        setTimeout(self.center(), 100);
    });

    $(msgX).on("click touchend", function() {
        self.close();
    });

    $(msgOver).on("click touchend", function() {
        self.close();
    });
}