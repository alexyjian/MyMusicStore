var ji = 0;
var widths=0;
var kais = 0;
var time;
function jis() {
     if(widths>540){
        clearInterval(time);
    }
    var jist = 'rotate(' + ji + 'deg' + ')';
    var min = document.getElementById('min');
    var jindu=document.getElementById('jindu');
    var dian = document.getElementById('dian');
    jindu.style.width=widths+'px';
    min.style.transform = jist;
    ji = ji + 0.1;
    widths=widths+0.03;
}
function opon() {
    kais++;
    if (kais == 1) {
        time = setInterval(jis, 10);
    }
    else {
       clearInterval(time);
       kais=0;
    }
    
}
