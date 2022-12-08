import { postRequestToNpAPI } from './postRequestToNpAPI';

export function NpOption({ url, setItems, setItemsAreLoading, regionRef = ``, cityRef = ``, typeOfWarehouseRef = ``, divRef, placeholder,
    setShowItems, showItems, itemsAreLoading, items, selectedItem, setSelectedItem, region = false, setCity, setPostOffice }) {
    return (
        <div className="flex">
            <div className="relative w-full items-center" ref={divRef}>
                <div className="relative w-full h-auto">
                    <input text="text" placeholder={placeholder} value={selectedItem.description}
                        className="outline-none block p-2 w-full text-xl font-semibold text-gray-900 bg-gray-50 rounded-lg border-gray-300 select-none shadow-lg"
                        onChange={(e) => {
                            setSelectedItem({ description: e.target.value, ref: '' });
                            setItemsAreLoading(true);
                            postRequestToNpAPI(url, setItems, setItemsAreLoading, regionRef, cityRef, typeOfWarehouseRef, e.target.value);
                            setShowItems(true);
                        }}
                        onClick={(e) => {
                            setItemsAreLoading(true);
                            postRequestToNpAPI(url, setItems, setItemsAreLoading, regionRef, cityRef, typeOfWarehouseRef, e.target.value);
                            setShowItems(true);
                        }}
                    />
                    {itemsAreLoading && (
                        <svg className="absolute top-[14px] right-0 animate-spin -ml-1 mr-3 h-5 w-5 text-black" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                        </svg>
                    )}
                </div>
                {showItems &&
                    <ul className="absolute h-36 bg-gray-50 w-full rounded-lg shadow-lg space-y-2 scrollbar overflow-y-scroll flex flex-col pb-2 z-50">
                        {itemsAreLoading ? (
                            < li className="text-xl font-semibold ml-2 cursor-pointer hover:text-[#3ba144] select-none">
                                <p>Зачекайте...</p>
                            </li>
                        ) : (
                            items.length === 0 ?
                                (
                                    <li className="text-xl font-semibold ml-2 cursor-pointer hover:text-[#3ba144] select-none">
                                        <p>Нічого не знайдено</p>
                                    </li>
                                ) :
                                (
                                    items.map((item) => (item.description !== 'АРК' && (
                                        <li key={item.ref} className="text-xl font-semibold ml-2 cursor-pointer hover:text-[#3ba144] select-none" name="region"
                                            onClick={() => { setSelectedItem({ description: item.description, ref: item.ref }); setShowItems(false); if (region) { setCity({ description: ``, ref: `` }); setPostOffice({ description: ``, ref: `` }); } }}>
                                            <p>{item.description}</p>
                                        </li>)
                                    ))
                                )
                        )}
                    </ul>
                }
            </div>
        </div>
    );
}