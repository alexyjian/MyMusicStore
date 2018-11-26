//页面加载完成时
window.onload=function(){
    var ul=document.getElementById('ad_ul');
    var ol=document.getElementById('ad_ol');
    //取所有子元素
    var ollis=ol.children;
    //用来控制left
    var leader=0;
    var target=0;
    var intr=1;
    //遍历ol
    for(var i=0;i<ollis.length;i++){
        // 每个li的索引号
        ollis[i].index=i;
        ollis[i].onmouseover=function(){
           for(var j=0;j<ollis.length;j++){
            ollis[j].className='';//去掉所有的class='current'
           }
           this.className='current';
           target=-this.index*490;//目标位置=当前index索引号*图片宽度
        }
    }
    setInterval(autoPlay,4000);
   function autoPlay(){
       for(var j=0;j<ollis.length;j++){
        ollis[j].className='';//去掉所有的class='current'
       }
       ollis[intr].className='current';
       target=-intr*490;
       intr++;
       if(intr==ollis.length){
           intr=0;
       }
   }

    //过度动画
    setInterval(function(){
        leader=leader+(target-leader)/100;
        ul.style.left=leader+'px';
    },2)
}