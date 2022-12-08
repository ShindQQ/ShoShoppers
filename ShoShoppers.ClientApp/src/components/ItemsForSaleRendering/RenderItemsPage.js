import { useState, useEffect } from 'react';
import { RenderItems } from './RenderItems';
import { ItemsFilter } from './ItemsFilter';
import { RenderItemsLabel } from './RenderItemsLabel';

export const RenderItemsPage = ({ _itemLabel, _showItemColorFilterOption, _renderItemsColors, _items, _showIndividual = false, _showShoppers = false, _showPins = false }) => {
    const [showFilterResult, setShowFilterResult] = useState(false);

    useEffect(() => {
        const timer = setTimeout(function () {
            setShowFilterResult(false);
        }, 2000);

        return () => { clearTimeout(timer); }
    }, [showFilterResult,])

    return (
        <div className="flex flex-col mt-4 mb-10 justify-center items-center">
            <RenderItemsLabel itemLabel={_itemLabel} _showIndividual={_showIndividual} _showShoppers={_showShoppers} _showPins={_showPins} />
            <ItemsFilter showItemColorFilterOption={_showItemColorFilterOption} renderItemsColors={_renderItemsColors} showFilterResult={showFilterResult} _setShowFilterResult={setShowFilterResult} />
            <RenderItems items={_items} _showFilterResult={showFilterResult} _setShowFilterResult={setShowFilterResult} />
        </div>
    );
}