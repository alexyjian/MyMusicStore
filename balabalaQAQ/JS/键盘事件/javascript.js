window.onload = function () {
    img = document.getElementById('img')
    img.style.left = 0;
    img.style.top = 0;
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;
        switch (e.keyCode) {
            //left 37
            case 37:
                img.style.left = (parseInt(img.style.left) - 3) + 'px';
                break;
            //top  38
            case 38:
                img.style.top = (parseInt(img.style.top) - 3) + 'px';
                break;
            case 39:
                //right 39
                img.style.left = (parseInt(img.style.left) + 3) + 'px';
                break;
            //bottom 40
            case 40:
                img.style.top = (parseInt(img.style.top) + 3) + 'px';
                break;
        }
    }
}

