;
var arr=new Array([1,2,3],[4,5]);
var name =prompt("请输入你的姓名","例如");
document.write(name);
window.onload = function () {
    var obj = document.getElementById('pp');
   
    obj.innerHTML=name;
    alert(name);
    
    if(obj.innerHTML=='例如')obj.style.color='#f00';
}