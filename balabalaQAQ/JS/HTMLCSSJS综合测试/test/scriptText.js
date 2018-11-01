function $(id) {
    return document.getElementById(id);
}
window.onload = function () {
    var target = 0;
    var targeted= 2525;
    var leader=0;
    var leadered=0;
    
    var ol_li = $('sn').children;
    
    var ol=0;

    var timer= setInterval(autoPlay,1000);
    
    //鼠标焦点控制
    for (var i = 0; i < ol_li.length; i++) {
        ol_li[i].index = i;
        ol_li[i].onmouseover =mousesover(); 
         
        ol_li[i].onmouseout=function(){
            timer=setInterval(autoPlay,1000);
        }
    }
    function mousesover () {
            
        window.clearInterval(timer);
        for (var j = 0; j < ol_li.length; j++) {
            ol_li[j].className = '';
        }
        this.className = 'sn_one';
        target = -this.index * 505;
    }

    setInterval(function () {
        leader = leader + (target - leader) / 10;
        leadered=leadered+(targeted-leadered)/10;
        $('imgs').style.left = leader + 'px';
        $('imgsfor').style.left= leadered + 'px';
    }, 20)
    function  autoPlay() {
        ol++;
        target=target-505;
        targeted =targeted-505;
        leader = leader + (target - leader) / 10;
        leadered=leadered+(targeted-leadered)/10;
        if(target<=-2500){
            $('imgsfor').style.display='block';
        }
        if(targeted<=-2500){
            $('imgs').style.display='block';
        }
        
        if(target<=-2600){
            target =2020; 
            $('imgs').style.display='none';
    
        }
        if(targeted<=-2600){
            $('imgsfor').style.display='none';
            targeted= 2020;
        }
        $('imgsfor').style.left= leadered + 'px';
        $('imgs').style.left = leader + 'px';
        
        for (var j = 0; j < ol_li.length; j++) {
            ol_li[j].className = '';
        }
        if(ol==5){
            ol=0;
        } 
        ol_li[ol].className = 'sn_one';
    }
}