// Obtenha o modal
var modal = document.getElementById("myModal");

// Obtenha o botão que abre o modal
var btn = document.getElementById("openModalBtn");

// Obtenha o botão de fechar do modal
var span = document.getElementsByClassName("close")[0];

// Quando o usuário clicar no botão, abra o modal
btn.onclick = function () {
    modal.style.display = "block";
}

// Quando o usuário clicar em <span> (x), feche o modal
span.onclick = function () {
    modal.style.display = "none";
}

// Quando o usuário clicar em qualquer lugar fora do modal, feche-o
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

// Lógica para lidar com a submissão do formulário
document.getElementById("itemForm").onsubmit = function (event) {
    event.preventDefault(); // Impede o envio do formulário

    // Lógica para lidar com a criação do item
    // Aqui você pode adicionar código para enviar os dados do formulário para o servidor, por exemplo

    // Feche o modal após a criação do item (você pode modificar isso conforme necessário)
    modal.style.display = "none";
}
