var sc = document.getElementById('sc');
var xia = document.getElementById('xia');
sc.onmouseover = function () {
    xia.style.display = 'block';
    sc.style.backgroundColor='white'
    xia.style.boxShadow='0px 8px 8px 0px rgba(0,0,0,0.2)';
    sc.style.border='1px solid #ccc';
    sc.style.borderBottom='0px';
    sc.style.borderTop='0px';
}
sc.onmouseout = function () {   
    xia.style.display = 'none';   
    sc.style.backgroundColor='rgb(247,247,247)';
    sc.style.border='0px solid #ccc';
    sc.style.borderBottom='0px';  sc.style.borderTop='0px';
}
xia.onmouseover = function () {
    xia.style.display = 'block'; 
    sc.style.backgroundColor='white';
    sc.style.border='1px solid #ccc';
    sc.style.borderBottom='0px'; 
     sc.style.borderTop='0px';
}
xia.onmouseout = function () {
    xia.style.display = 'none';
    sc.style.backgroundColor='rgb(247,247,247)';
    sc.style.border='0px solid #ccc';
    sc.style.borderBottom='0px';  
    sc.style.borderTop='0px';
}