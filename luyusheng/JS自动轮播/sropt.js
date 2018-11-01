window.onload=function(){
    var naoll=document.getElementById('naoll');
    var ul=document.getElementById('on_ul');
    var ol=document.getElementById('on_ol').getElementsByTagName("li");
    var timer=null;
    var leader=0;
    var target=0;
    
    var 

    //自动播放设置
    if(timer){
       clearInterval(timer);
       timer=null;
   }  
    var ollis=ol.children;
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
            Animation(ul) -this.index * 500;
        }
    }
    //动画，每20秒 left的值如何变化
    setInterval(function(){
        leader=leader + (target-leader)/10;
        ul.style.left=leader + 'px';
    },100)
}