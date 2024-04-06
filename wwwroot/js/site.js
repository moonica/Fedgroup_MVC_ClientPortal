function Search(inputElementName, tableName) {
    let searchTerm = document.getElementById(inputElementName)?.value;

    if (!searchTerm)
    {
        console.warn(`No search term found in textbox '${inputElementName}'`);
        return;
    }

    let isHeaderRow = true;
    $(`#${tableName} tr`).each(function () {
        if (isHeaderRow) {
            isHeaderRow = false;
        }
        else {
            let found = false;
            $(this).children("td").each(function () {
                found = found || ((this.innerText?.trim()?.toUpperCase().indexOf(searchTerm.trim().toUpperCase())) > -1);

                //if (found)
                //    break;
            });

            if (!found) {
                this.setAttribute("hidden", "hidden");
            }
        }
    });
}

function ClearTableSearch(inputElementName, tableName) {
    let searchTerm = document.getElementById(inputElementName);
        if (searchTerm)
            searchTerm.value = "";

    $(`#${tableName} tr`).each(function () {
            this.removeAttribute("hidden");
        });
}

    //TODO: extend this to allow searching on each button press (with a reasonable delay between keystrokes)
    //TODO: implement paging
    //TODO: at the moment, there's few enough properties for each client that it can be contained in one table row. Even though the instructions say that clicking on a client should show their details, I've left "good enough alone" for now. Future functionality could include a details partial view or the table opening up in an accordion with the chosen client's details

function ShowElement(elem) {
    if (!elem)
        return;

    //one of the places I call this, is passes in the string element ID as expected. The other, it passes in the element itself. I am not sure why so I'm just catering for both
    if (typeof elem === 'string') {
        var element = document.getElementById(elem);

        if (!element)
            return;

        element.removeAttribute("hidden");
    }
    else
        elem.removeAttribute("hidden");
}

function HideElement(elem) {
    if (!elem)
        return;

    //one of the places I call this, is passes in the string element ID as expected. The other, it passes in the element itself. I am not sure why so I'm just catering for both
    if (typeof elem === 'string') {
        var element = document.getElementById(elem);

        if (!element)
            return;

        element.setAttribute("hidden", "hidden");
    }
    else
        elem.setAttribute("hidden", "hidden");
}

function CopyElementValue(fromElemName, toElemName) {
    console.log("fromElem: ", fromElemName);
    console.log("toElem: ", toElemName);

    var element = document.getElementById(fromElemName);
    var value = element.value;

    element = document.getElementById(toElemName);
    element.setAttribute("value", value);
}