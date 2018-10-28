var ji = 0;
var widths=0;
var kais = 0;
function jis() {
    var jist = 'rotate(' + ji + 'deg' + ')';
    var min = document.getElementById('min');
    var jindu=document.getElementById('jindu');
    var dian = document.getElementById('dian');
    jindu.style.width=widths+'px';
    min.style.transform = jist;
    ji = ji + 0.1;
    widths=widths+0.1;
}
function opon() {
    kais++;
    if (kais == 1) {
        time = setInterval(jis, 40);
    }
    else {
       clearInterval(time);
       kais=0;
    }
}
