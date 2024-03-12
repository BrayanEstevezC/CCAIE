var getElement = id => document.getElementById(id);
var getElements = className => document.getElementsByClassName(className);

const icon = getElement("icon");
const nav = getElement("nav");
const iconClick = () => {
    nav.classList.toggle("bg-white");
    nav.classList.toggle("text-dark");
}
icon.onclick = iconClick;

window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    var animation = getElement("animation");
    const navegation = getElement("nav");
    header.classList.toggle("bg-white", window.scrollY > 0);
    navegation.classList.toggle("navbar-light", window.scrollY > 0);
    navegation.classList.toggle("navbar-dark", window.scrollY < 1);
    icon.classList.toggle("d-block", window.scrollY < 0);
    icon.classList.toggle("d-none", window.scrollY < 1);
    if (animation) {
        animation.classList.toggle("fade-in-container", window.scrollY > 0);
    }
});



