var getElement = id => document.getElementById(id);
var getElements = className => document.getElementsByClassName(className);
window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    var nav = document.querySelector("a");
    var animation = getElement("animation");
    const navegation = getElement("nav");
    header.classList.toggle("bg-white", window.scrollY > 0);
    navegation.classList.toggle("navbar-light", window.scrollY > 0);
    navegation.classList.toggle("navbar-dark", window.scrollY < 1);
    animation.classList.toggle("fade-in-container", window.scrollY > 0);
});

const icon = getElement("icon");
const nav = getElement("nav");
const iconClick = () => {
    nav.classList.toggle("bg-white");
    nav.classList.toggle("navbar-light");
    nav.classList.toggle("navbar-dark");
}
icon.onclick = iconClick;

