function $(id){
    return document.getElementById(id);
}
//页面加载完成时发生
window.onload= function(){
    var target=0;
    var leader=0;

    //鼠标悬停显示箭头
    $("box").onmouseover=function(){
        $("arrow").style.display='block';
    }

    //鼠标移除隐藏箭头
    $("box").onmouseout=function(){
        $("arrow").style.display='none';
    }

    //点击箭头，左箭头left-520，右箭头right+520
    $("left").onclick=function(){
        target+=520;
    }
    $("right").onclick=function(){
        target-=520;
    }

    //切换动画，把ul的left属性设置为对应的值
    setInterval(function(){
        if(target>=0){
            target=0;
        }
        if(target<=-2080){
            target=-2080;
        }
        leader=leader+(target-leader)/10;
        $("ad_imgs").style.left=leader+'px';
    },30);
}