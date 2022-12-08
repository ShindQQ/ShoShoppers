import { React } from 'react';

export const RenderColorsFilters = ({ height, itemColorRef, setShowFilterOptions, showFilterOptions, items, filterFunction, itemFilterOption }) => {
    return (
        <div ref={itemColorRef} className="h-full flex-col items-center justify-center w-full pt-2 lg:pt-0 relative">
            <button
                className="w-full lg:w-56 h-full flex justify-center items-center cursor-pointer text-lg font-medium"
                onClick={() => setShowFilterOptions(!showFilterOptions)}>
                <p>Оберіть колір {itemFilterOption}</p>
                <svg className={`ml-2 w-4 h-4 transition-all duration-300 ${showFilterOptions && "rotate-180"}`} aria-hidden="true" fill="none"
                    stroke="currentColor" viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 9l-7 7-7-7"></path>
                </svg>
            </button>
            <ul className={`${height} w-full lg:pt-2 lg:w-56 absolute left-0 lg:left-auto bg-white z-20 rounded-b-xl drop-shadow-xl text-lg font-medium bg-gray-200 scrollbar overflow-y-scroll transition-all duration-300 origin-top ${showFilterOptions ? "scale-100" : "scale-0"}`}>
                {items.map((item, index) => (
                    <li key={index} onClick={() => {
                        filterFunction(item, index);
                    }}>
                        {item.colorInFilter ? (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-48 ring-2 ring-[#3ba144]">
                                <div className={`h-full w-1/5 bg-white mr-3 rounded-l-md drop-shadow-lg ${item.itemColorCSS}`}></div>
                                <p>{item.itemColorText}</p>
                            </button>
                        ) : (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-48">
                                <div className={`h-full w-1/5 bg-white mr-3 rounded-l-md drop-shadow-lg ${item.itemColorCSS}`}></div>
                                <p>{item.itemColorText}</p>
                            </button>
                        )}
                    </li>
                ))}
            </ul>
        </div>
    );
};
