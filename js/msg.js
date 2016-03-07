// msg.js
// author: Collen Irwin
// requires: jQuery, #msg div, #msgTitle div, #msgBody div, #msgFoot div, #msgOver div
// desc: basic messagebox class, alert replacer

var Msg = function() {

    // Vars

    this.title = "";
    this.body = "";
    this.foot = "";

    var msg = document.getElementById("msg"),
        msgTitle = document.getElementById("msgTitle"),
        msgBody = document.getElementById("msgBody"),
        msgFoot = document.getElementById("msgFoot"),
        msgOver = document.getElementById("msgOver")

    var self = this; // Hack needed to avoid losing 'this' somehow (really, javascript?)
    var xButton = '<input type="button" id="msgX" class="msgButton ol" style="float:right;width:30px;" value="x" />';

    // End Vars
    
    // Main Methods

    this.init = function(title, body, foot) {
        self.title = title;
        self.body = body;
        self.foot = foot;
    }

    this.show = function(buttons) { 
        $(msgTitle).html(self.title);
        $(msgTitle).append(xButton);
        $(msgBody).html(self.body);
        $(msgFoot).html(self.foot);

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

    // End Main Methods

    // Events

    $(window).on("resize", function() { // center on resize
        setTimeout(self.center(), 100);
    });

    $(msg).on("click touchend", "#msgX", function() {
        self.close();
    });

    $(msgOver).on("click touchend", function() {
        self.close();
    });

    // End Events
}