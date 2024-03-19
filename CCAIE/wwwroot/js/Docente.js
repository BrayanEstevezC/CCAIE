function validarFormulario(event) {
    event.preventDefault();

    var nombre = document.getElementById("nombre").value;
    var telefono = document.getElementById("telefono").value;
    var email = document.getElementById("email").value;
    
    var telefonoRegex = /^\d{10}$/;

    // Validar nombre
    if (!nombre.trim()) {
        mostrarAlerta("nombreAlerta", "Por favor ingresa su nombre completo.", "alert-danger");
        return;
    }

    // Validar número de teléfono
    if (!telefonoRegex.test(telefono)) {
        mostrarAlerta("telefonoAlerta", "Por favor ingresa un número de teléfono válido de 10 dígitos.", "alert-danger");
        return;
    }

    // Validar correo electrónico
    if (!isValidEmail(email)) {
        mostrarAlerta("emailAlerta", "Por favor ingresa un correo electrónico válido.", "alert-danger");
        return;
    }

    document.getElementById("correoForm").submit();
}

function isValidEmail(email) {
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function mostrarAlerta(id, mensaje, clase) {
    var alertaDiv = document.getElementById(id);
    alertaDiv.className = "alert " + clase;
    alertaDiv.innerText = mensaje;
    alertaDiv.style.display = "block";
}