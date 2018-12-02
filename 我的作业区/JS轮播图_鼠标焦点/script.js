window.onload=function(){
    var oUl = document.getElementById('ul');
    var aLi_u = oUl.getElementsByTagName('li');
    var oOl = document.getElementById('ol');
    var aLi_o = oOl.getElementsByTagName('li');
    for(var i = 0; i<aLi_o.length; i++){
        aLi_o[i].index=i;
        aLi_o[i].onmouseover = function(){
            for(var i = 0; i<aLi_o.length; i++){
                aLi_o[i].className='';
                aLi_u[i].style.display='none';
            }
            this.className ='current';
            aLi_u[this.index].style.display ='block';
        }
    }
}
