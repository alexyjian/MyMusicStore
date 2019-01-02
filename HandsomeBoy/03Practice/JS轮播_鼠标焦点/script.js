window.onload = function () {

   var slider = document.getElementById('slider')
   var ul = document.getElementById('ad_ul')
   var ol = document.getElementById('ad_ol')

   var ollis = ol.children;
   var leader = 0;
   var target = 0;

   for(var i =0;i<ollis.length;i++){
    //    每一个li的索引号
       ollis[i].index=i;
       ollis[i].onmouseover= function(){
             for(var j =0;j<ollis.length;j++)
             {
                  ollis[j].className='';//去掉所有的class='current'
             }
             this.className = 'current';
             target = -this.index * 490;
       }
   }
   setInterval(function(){
       leader = leader + (target - leader) / 10;
       ul.style.left = leader + 'px';
   },20)
}