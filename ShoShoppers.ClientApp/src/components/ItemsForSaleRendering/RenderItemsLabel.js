import { useEffect } from 'react';
import { CartState } from '../../context/Context';

export const RenderItemsLabel = ({ itemLabel, _showIndividual, _showShoppers, _showPins }) => {
    const {
        dispatch,
    } = CartState();

    useEffect(() => {
        if (!_showIndividual && !_showShoppers && !_showPins) {
            dispatch({ type: "GO_TO_MAIN" })
        }
        else if (_showIndividual) {
            dispatch({ type: "GO_TO_INDIVIDUAL" })
        }
        else if (_showShoppers) {
            dispatch({ type: "GO_TO_SHOPPERS" })
        }
        else if (_showPins) {
            dispatch({ type: "GO_TO_PINS" })
        }

    }, [dispatch, _showIndividual, _showPins, _showShoppers]);

    return (
        <div className="flex justify-center mb-4">
            <h1 className="text-3xl font-medium text-[#3ba144] text-center drop-shadow-lg">{itemLabel}</h1>
        </div>
    );
};
