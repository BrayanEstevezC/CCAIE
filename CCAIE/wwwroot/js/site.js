var getElement = id => document.getElementById(id);
var getElements = className => document.getElementsByClassName(className);
window.addEventListener("scroll", function () {
    var header = document.querySelector("header");
    var nav = document.querySelector("a");
    var animation = getElement("animation");
    header.classList.toggle("bg-white", window.scrollY > 0);
    nav.classList.toggle("color", window.scrollY > 0);
    animation.classList.toggle("fade-in-container", window.scrollY > 0);
});

const icon = getElement("icon");
const nav = getElement("nav");
const iconClick = () => {
    nav.classList.toggle("bg-white");
}
icon.onclick = iconClick;

