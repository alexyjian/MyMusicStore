window.onload = function () {
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;
        //left 37
        if (e.keyCode == 37){
            document.getElementById('img').style.transform='10px';
        }
            //top  38
        if (e.keyCode == 38)
            //right 39
        if (e.keyCode == 39)
        //bottom 40
        if (e.keyCode == 40)
        
    }
}


