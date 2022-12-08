export async function postRequestToNpAPI(url, setItems, setItemsAreLoading, regionRef, cityRef, typeOfWarehouseRef, findByString) {
    const response = await fetch(url, {
        method: 'POST',
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify({
            'RegionRef': regionRef,
            'CityRef': cityRef,
            'TypeOfWarehouseRef': typeOfWarehouseRef,
            'FindByString': findByString,
        })
    });

    setItems(await response.json());
    setItemsAreLoading(false);
}