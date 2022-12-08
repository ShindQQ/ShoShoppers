export async function SetItems(setItems) {
    setItems((await fetch('/api/Pin').then(response => response.json())).concat(await fetch('/api/Shopper').then(response => response.json())));
}

export function checkItemsAmmount(items, itemForCheck) {
    const item = items.find(item => item.name === itemForCheck.name);

    return typeof item !== "undefined" ? item.itemAmmount === 0 : false;
}
