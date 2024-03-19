const open = document.getElementById('open');
const main = document.getElementById('content-main');

let modalActive = null;

const Modal = (titulo, mensaje, tipo) => {
    // Elimina el modal activo si existe
    modalActive ? modalActive.remove() : null;

    // Crea el contenido del modal
    const modalBody = document.createElement("section");
    modalBody.classList.add("modalJS", tipo, 'active'); // Agrega la clase 'active' al modal

    // Crea el icono
    const iconContent = document.createElement("div");
    const icon = document.createElement("div");
    iconContent.classList.add("iconContent");
    iconContent.appendChild(icon);
    switch (tipo) {
        case true:
            icon.classList.add("check-icon", "mb-2", "iconos");
            break;
        case false:
            icon.classList.add("close", "mb-2", "iconos");
            break;
        default:
            icon.classList.add("exclamation-icon", "mb-2", "iconos", "orange");
            icon.textContent = '!';
            break;
    }
    modalBody.appendChild(iconContent);

    // Agrega el título
    const tituloModal = document.createElement("h1");
    tituloModal.innerText = titulo;
    modalBody.appendChild(tituloModal);

    // Agrega el mensaje
    const mensajeModal = document.createElement("h3");
    mensajeModal.innerText = mensaje;
    mensajeModal.classList.add('py-2');
    modalBody.appendChild(mensajeModal);

    // Agrega el botón de cierre
    const btnClose = document.createElement("button");
    btnClose.innerText = " Ok";
    btnClose.classList.add("btnClose");

    btnClose.addEventListener("click", () => {
        modalBody.remove();
    });
    modalBody.appendChild(btnClose);

    // Agrega el modal al documento
    main.appendChild(modalBody);

    // Almacena el modal activo
    modalActive = modalBody;
}

// Abre el modal al hacer clic en el botón
Modal("¡Error!", "¡Opps! alparecer ocurrio un error", false);