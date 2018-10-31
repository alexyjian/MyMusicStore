window.onload=function(){
    var naoll=document.getElementById('naoll');
    var ul=document.getElementById('on_ul');
    var ol=document.getElementById('on_ol');
    var ollis=ol.children;
    var leader=0;
    var target=0;

    for(var i=0; i<ollis.length; i++){
        //每个li的索引号
        ollis[i].index=i;
        ollis[i].onmouseover=function(){
            for(var j=0; j<ollis.length; j++){
                //去掉所有的class='arroet'
                ollis[j].className='';
            }
            this.className='arroet';
            //目标位置=当前index乘以图片宽度
            target= -this.index * 490;
        }
    }
    //动画，每20秒 left的值如何变化
    setInterval(function(){
        leader=leader + (target-leader)/10;
        ul.style.left=leader + 'px';
    },20)
     //鼠标悬停事件
     naoll.onmouseover=function(){
        clearInterval(timer);
    }
    naoll.onmouseout=function(){
        timer=setInterval(autoPlay,10);
    }
}