function change(id, mode) {
    document.getElementById(id).style.display = mode;
    
    if (mode == 'block') {
        document.getElementById(id).style.border = '1px solid #eee';
        document.getElementById(id).style.borderTop = 'none';


        document.getElementById(id).parentNode.style.backgroundColor = '#fff';
        document.getElementById(id).parentNode.style.border = '1px solid #eee';
        document.getElementById(id).parentNode.style.borderBottom = 'none';
    }
else {
        document.getElementById(id).parentNode.style.backgroundColor = '';
        document.getElementById(id).parentNode.style.border = '';
    }
}