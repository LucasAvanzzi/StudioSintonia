// Obtenha o modal
var modal = document.getElementById("myModal");

// Obtenha o bot�o que abre o modal
var btn = document.getElementById("openModalBtn");

// Obtenha o bot�o de fechar do modal
var span = document.getElementsByClassName("close")[0];

// Quando o usu�rio clicar no bot�o, abra o modal
btn.onclick = function () {
    modal.style.display = "block";
}

// Quando o usu�rio clicar em <span> (x), feche o modal
span.onclick = function () {
    modal.style.display = "none";
}

// Quando o usu�rio clicar em qualquer lugar fora do modal, feche-o
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

// L�gica para lidar com a submiss�o do formul�rio
document.getElementById("itemForm").onsubmit = function (event) {
    event.preventDefault(); // Impede o envio do formul�rio

    // L�gica para lidar com a cria��o do item
    // Aqui voc� pode adicionar c�digo para enviar os dados do formul�rio para o servidor, por exemplo

    // Feche o modal ap�s a cria��o do item (voc� pode modificar isso conforme necess�rio)
    modal.style.display = "none";
}
