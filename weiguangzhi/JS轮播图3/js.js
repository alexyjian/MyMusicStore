window.onload=function(){

    var ol= document.getElementById('ol').getElementsByTagName('li');

    var current_index=0;

    for(var i=0;i<ol.length;i++)
    {
        ol[i].onmouseover=function(){
            if(i!=current_index){
                ol[current_index].style.backgroundColor='';
                ol[current_index].style.borderBottom='';
            }

        var ad_ul=document.getElementById('ad').getElementsByTagName('ul');

        for(var i=0;i<ad_ul.length;i++){
                ad_ul[i].className=ad_ul.className.replace(' current','');
                ol[i].className=ol.className.replace(' current','');

                if(ol[i]==  this){
                    this.className+=' current';
                    ad_ul[i].className+=' current';

                }

        }
    }
      // 添加鼠标的移除事件
      ol[i].onmouseover=function(){
        timer=setTimeout(autuCheck,5000);
    }
}
}