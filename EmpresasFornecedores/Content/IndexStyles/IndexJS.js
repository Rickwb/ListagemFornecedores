function EditarEmpresa() {
    document.URL ="https://localhost:44387/Empresas/Edit/1"
}

function AlterarCor()
{
    var elemento = document.getElementById('mudaCor');
    elemento.onmouseover(function () {
        elemento.style.color = "red";
    })
    elemento.onmouseout(function () {
        elemento.style.color = "black";
    })
}

function VoltaCor() {
    var texto = document.getElementById('mudaCor')
    texto.style.color = "black";
}

function NavMover() {
    var nav = document.getElementById("mover");
    window.addEventListener("scroll", function () {
        nav.classList.toggle("sticky", window.screenY > 0);
    })
   
}

