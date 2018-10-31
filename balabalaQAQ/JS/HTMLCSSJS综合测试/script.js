function $(id) {
    return document.getElementById(id);
}
window.onload = function () {
    var target = 0;
    var leader=0;
    var ol_li = $('sn').children;
    var ol=0;

    var timer= setInterval(autoPlay,3000);
    
    //鼠标焦点控制
    for (var i = 0; i < ol_li.length; i++) {
        ol_li[i].index = i;
        ol_li[i].onmouseover = function () {
            clearInterval(timer);
            for (var j = 0; j < ol_li.length; j++) {
                ol_li[j].className = '';
            }
            this.className = 'sn_one';
            target = -this.index * 505;
        }
        ol_li[i].onmouseout=function(){
            setInterval(autoPlay,3000);
        }
    }
    setInterval(function () {
        leader = leader + (target - leader) / 10;
        $('imgs').style.left = leader + 'px';
    }, 20)
    /*鼠标焦点控制end*/ 

    /*自动轮播*/ 
    function  autoPlay() {
        ol_li[ol].index = ol;  
        ol++;

        if(ol!=0){
            ol_li[0].className=''; 
        }
        target=target-505;
        target <= -2100 ? target = 0 : target;
        leader = leader + (target - leader) / 10;
        $('imgs').style.left = leader + 'px';
        
       
        ol_li[ol-1].className=''; 
        if(ol==5){
            ol_li[0].className = 'sn_one';
            ol=0;
            ol_li[4].className=''; 
            $('imgs').style.left = 0 + 'px';
        }    
        ol_li[ol].className = 'sn_one';
    }
    /*自动轮播end*/ 
}