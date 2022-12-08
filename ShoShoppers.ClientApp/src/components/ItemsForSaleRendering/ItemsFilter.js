import { RenderFilters } from "./RenderFilters"
import { Search } from '../FilterOptions/Search';
import { useState, useRef } from 'react';
import { useOnClickOutside } from '../ClickOutside/useOnClickOutside';
import { BurgerMenu } from '../Header/BurgerMenu';

export const ItemsFilter = ({ showItemColorFilterOption, renderItemsColors, _showFilterResult, _setShowFilterResult }) => {
    const [showFilters, setShowFilters] = useState(false);
    const [_itemsColors, setItemsColors] = useState(renderItemsColors);
    const ref = useRef();

    useOnClickOutside(ref, () => setShowFilters(false));

    return (
        <div className="w-full h-auto bg-gray-200 mb-4 items-center flex justify-center py-2">
            <div ref={ref} className="flex space-x-4 lg:space-x-12">
                <Search showFilterResult={_showFilterResult} setShowFilterResult={_setShowFilterResult} />
                <div className="hidden lg:flex">
                    <RenderFilters showItemColorFilterOption={showItemColorFilterOption} renderItemsColors={_itemsColors} setRenderItemsColors={setItemsColors} showFilterResult={_showFilterResult} setShowFilterResult={_setShowFilterResult} />
                </div>
                <div className="ml-6 lg:hidden items-center flex-column justify-center relative">
                    <BurgerMenu setState={setShowFilters} state={showFilters} />
                    <div className={`absolute top-8 w-72 right-0 bg-gray-200 border-b-1 border-gray-300 rounded-b-lg shadow-xl mt-5 z-50 transition-all duration-300 origin-top-right ${showFilters ? " scale-100" : "scale-0"}`}>
                        <RenderFilters showItemColorFilterOption={showItemColorFilterOption} renderItemsColors={_itemsColors} setRenderItemsColors={setItemsColors} showFilterResult={_showFilterResult} setShowFilterResult={_setShowFilterResult} />
                    </div>
                </div>
            </div>
        </div>
    );
};
