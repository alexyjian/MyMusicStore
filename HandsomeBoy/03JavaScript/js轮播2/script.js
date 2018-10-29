window.onload = function () {
    var timer =null;

    function $(id) {
        return document.getElementById(id);
    }
    var pic_a = $('box').getElementsByTagName('a');
    var pic_index = 0;
    for (var i = 0; i < pic_a.length; i++) {
        pic_a[i].onmouseover = function () {
            clearInterval(timer);
            if (i === pic_index) {
                pic_a[pic_index].style.zIndex = '99';
            }
            console.log(pic_index);
            console.log(pic_a[i]);
        }
    }
    
}