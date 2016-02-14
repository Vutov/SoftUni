var Container = Container || {},
    Section = Section || {},
    Item = Item || {};

Container = function () {
    if (!(this instanceof Container)) {
        return new Container();
    }

    this.sections = [];

    return this;
};

Container.prototype = function () {
    var addSection = function (section) {
        this.sections.push(section);
    },
        addToDom = function () {
            var container = document.getElementById("container");
            var sectionWrapper = document.createElement("div");
            var header = document.createElement('h1');
            header.textContent = "TODO List";
            container.appendChild(header);

            this.sections.forEach(function (s) {
                var section = s.addToDOM();
                sectionWrapper.appendChild(section);
            });

            var addTitleContainer = document.createElement("div");
            var titleField = document.createElement("input");
            titleField.type = "text";
            titleField.placeholder = "Title...";
            titleField.setAttribute("id", "SectionField");
            var addBtn = document.createElement("input");
            addBtn.type = "button";
            addBtn.value = "New Section";
            addBtn.addEventListener("click", addHtmlSection.bind(this, sectionWrapper));

            addTitleContainer.appendChild(titleField);
            addTitleContainer.appendChild(addBtn);

            container.appendChild(sectionWrapper);
            container.appendChild(addTitleContainer);

            return sectionWrapper;
        },
        addHtmlSection = function (container) {
            var sectionField = document.getElementById("SectionField");
            var sectionData = sectionField.value;
            sectionField.value = "";
            var section = Section(sectionData, []);
            var htmlSection = section.addToDOM();
            container.appendChild(htmlSection);
            this.sections.push(section);
        };

    return {
        addSection: addSection,
        addToDOM: addToDom
    }
}();

Section = function (title, items) {
    if (!(this instanceof Section)) {
        return new Section(title, items);
    }

    this.title = title;
    this.items = items;

    return this;
};

Section.prototype = function () {
    var addToDom = function () {
        var sectionWrapper = document.createElement('div');
        var section = document.createElement('section');

        var sectionTitle = document.createElement('div');
        sectionTitle.textContent = this.title;
        section.appendChild(sectionTitle);

        this.items.forEach(function (i) {
            var item = i.addToDOM();
            section.appendChild(item);
        });

        var addDiv = document.createElement('div');
        var field = document.createElement("input");
        field.type = "text";
        field.placeholder = "Add item...";
        field.setAttribute("id", "ItemField");
        var addBtn = document.createElement("input");
        addBtn.type = "button";
        addBtn.value = "+";
        addBtn.addEventListener("click", addItem.bind(this, section));

        addDiv.appendChild(field);
        addDiv.appendChild(addBtn);
        sectionWrapper.appendChild(section);
        sectionWrapper.appendChild(addDiv);

        return sectionWrapper;
    }, addItem = function (section, e) {
        var itemField = e.target.parentNode.children[0];
        var itemData = itemField.value;
        itemField.value = "";
        var item = Item(itemData, "unchecked");
        var htmlItem = item.addToDOM();
        section.appendChild(htmlItem);
        this.items.push(item);
    };

    return {
        addToDOM: addToDom
    }
}();

Item = function (content, status) {
    if (!(this instanceof Item)) {
        return new Item(content, status);
    }

    this.content = content;
    this.status = status;

    return this;
};

Item.prototype = function () {
    var addToDom = function () {
        var item = document.createElement("div");

        var checkbox = document.createElement("input");
        checkbox.type = "checkbox";

        var content = document.createElement("div");
        content.textContent = this.content;
        content.style.display = 'inline';

        if (this.status === "checked") {
            checkbox.setAttribute("checked", "checked");
            checkbox.checked = true;
            item.style.backgroundColor = '#00FF00';
        }

        item.appendChild(checkbox);
        item.appendChild(content);
        item.addEventListener("click", checkUncheck.bind(this));

        return item;
    },
        checkUncheck = function (e) {
            var checkbox = e.currentTarget.children[0];
            var wrapper = e.currentTarget;
            if (checkbox.getAttribute("checked")) {
                checkbox.removeAttribute("checked");
                checkbox.checked = false;
                wrapper.style.backgroundColor = "white";
            } else {
                checkbox.setAttribute("checked", "checked");
                checkbox.checked = true;
                wrapper.style.backgroundColor = '#00FF00';
            }
        };

    return {
        addToDOM: addToDom
    }
}();

var container = new Container();

var items = [
    new Item("Air-Freshener", "unchecked"),
    new Item("Pampers", "unchecked"),
    new Item("Newspaper", "unchecked"),
    new Item("Toiler paper", "checked"),
];

var shoppingSection = new Section("Shopping List", items);
container.addSection(shoppingSection);

container.addToDOM();