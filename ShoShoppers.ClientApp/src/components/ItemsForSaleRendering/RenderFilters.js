import { React, useState, useRef } from 'react';
import { itemsImagesColors }  from "./ColorsData"
import { CartState } from '../../context/Context';
import { useOnClickOutside } from '../ClickOutside/useOnClickOutside';
import { RenderColorsFilters } from './RenderColorsFilters';

export const RenderFilters = ({ showItemColorFilterOption, renderItemsColors, setRenderItemsColors, showFilterResult, setShowFilterResult }) => {
    const {
        itemsDispatch,
        itemsState: { byItemsColors, byItemsImagesColors, sortByAscending, sortByDescending },
    } = CartState();

    const [showColorFilterOptions, setShowColorFilterOptions] = useState(false);
    const itemColorRef = useRef();
    useOnClickOutside(itemColorRef, () => setShowColorFilterOptions(false));

    const [showImageColorFilterOptions, setShowImageColorFilterOptions] = useState(false);
    const itemImageColorRef = useRef();
    useOnClickOutside(itemImageColorRef, () => setShowImageColorFilterOptions(false));

    const [showSortPriceOptions, setShowSortPriceOptions] = useState(false);
    const sortPriceRef = useRef();
    useOnClickOutside(sortPriceRef, () => setShowSortPriceOptions(false));

    const [_itemsImagesColors, setItemsImagesColors] = useState(itemsImagesColors);

    const itemsFilterByColors = (item, index) => {
        const newItemsColors = [...renderItemsColors];
        newItemsColors[index].colorInFilter = !item.colorInFilter;
        setRenderItemsColors(newItemsColors);
        byItemsColors.find((c) => c.itemColorText === item.itemColorText) === undefined ?
            itemsDispatch({ type: "ADD_TO_FILTER_BY_COLOR", payload: item, }) :
            itemsDispatch({ type: "REMOVE_FROM_FILTER_BY_COLOR", payload: item, })
        showFilterResult ? setShowFilterResult(false) : setShowFilterResult(true);
    }

    const itemsFilterByImageColors = (item, index) => {
        const newItemsColors = [..._itemsImagesColors];
        newItemsColors[index].colorInFilter = !item.colorInFilter;
        setItemsImagesColors(newItemsColors);
        byItemsImagesColors.find((c) => c.itemColorText === item.itemColorText) === undefined ?
            itemsDispatch({ type: "ADD_TO_FILTER_BY_IMAGE_COLOR", payload: item, }) :
            itemsDispatch({ type: "REMOVE_FROM_FILTER_BY_IMAGE_COLOR", payload: item, })
        showFilterResult ? setShowFilterResult(false) : setShowFilterResult(true);
    }

    return (
        <div className="h-full mx-0 lg:mx-2 flex-сol space-y-4 lg:space-y-0 lg:flex lg:space-x-8 items-center justify-center my-auto select-none">
            <RenderColorsFilters height={"h-auto"} itemColorRef={itemColorRef} setShowFilterOptions={setShowColorFilterOptions} showFilterOptions={showColorFilterOptions} items={renderItemsColors} filterFunction={itemsFilterByColors} itemFilterOption={showItemColorFilterOption} />
            <RenderColorsFilters height={"h-[204px]"} itemColorRef={itemImageColorRef} setShowFilterOptions={setShowImageColorFilterOptions} showFilterOptions={showImageColorFilterOptions} items={_itemsImagesColors} filterFunction={itemsFilterByImageColors} itemFilterOption={"малюнку"} />
            <div ref={sortPriceRef} className="h-full flex-col items-center justify-center w-full pt-2 lg:pt-0 relative pb-4 lg:pb-0">
                <button
                    className="w-full lg:w-44 h-full flex justify-center items-center cursor-pointer text-lg font-medium"
                    onClick={() => setShowSortPriceOptions(!showSortPriceOptions)}>
                    <p>Сортування</p>
                    <svg className={`ml-2 w-4 h-4 transition-all duration-300 ${showSortPriceOptions && "rotate-180"}`} aria-hidden="true" fill="none"
                        stroke="currentColor" viewBox="0 0 24 24"
                        xmlns="http://www.w3.org/2000/svg">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 9l-7 7-7-7"></path>
                    </svg>
                </button>
                <ul className={`h-auto w-full lg:pt-2 lg:w-44 absolute left-0 lg:left-auto bg-white z-20 rounded-b-xl drop-shadow-xl text-lg font-medium bg-gray-200 transition-all duration-300 origin-top ${showSortPriceOptions ? " scale-100" : "scale-0"}`}>
                    <li onClick={() => {
                        if (!sortByDescending)
                            itemsDispatch({ type: "SORT_ASCENDING", payload: !sortByAscending, });
                        if (sortByDescending) {
                            itemsDispatch({ type: "SORT_DESCENDING", payload: false, });
                            itemsDispatch({ type: "SORT_ASCENDING", payload: true, });
                        }
                    }}>
                        {sortByAscending ? (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-36 ring-2 ring-[#3ba144] text-center flex justify-center">
                                <p>За зростанням</p>
                            </button>
                        ) : (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-36 text-center flex justify-center">
                                <p>За зростанням</p>
                            </button>
                        )}
                    </li>
                    <li onClick={() => {
                        if (!sortByAscending)
                            itemsDispatch({ type: "SORT_DESCENDING", payload: !sortByDescending, });
                        if (sortByAscending) {
                            itemsDispatch({ type: "SORT_DESCENDING", payload: true, });
                            itemsDispatch({ type: "SORT_ASCENDING", payload: false, });
                        }
                    }}>
                        {sortByDescending ? (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-36 ring-2 ring-[#3ba144] text-center flex justify-center">
                                <p>За спаданням</p>
                            </button>
                        ) : (
                            <button className="flex items-center bg-white rounded-md mx-auto my-2 h-10 w-36 text-center flex justify-center">
                                <p>За спаданням</p>
                            </button>
                        )}
                    </li>
                </ul>
            </div>
        </div>
    );
};
