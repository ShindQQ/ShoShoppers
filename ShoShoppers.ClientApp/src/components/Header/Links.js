import { CartState } from '../../context/Context';

export const Links = () => {
    const {
        state: { showIndividual, showShoppers, showPins },
        dispatch,
    } = CartState();

    return (
        <ul className="flex flex-col content-center font-medium xl:flex-row xl:space-x-8 z-50 relative select-none w-auto">
            <li className={`${showIndividual || showShoppers || showPins ? "block" : "hidden"}`}>
                <a href="/"
                    onClick={() => dispatch({
                        type: "GO_TO_MAIN"
                    })}
                    className="block p-2 text-2xl text-white hover:bg-[#43b552] xl:hover:bg-transparent xl:hover:text-white xl:text-white link link-underline link-underline-white xl:py-3 xl:mt-[6px]">
                    <p>На головну</p>
                </a>
            </li>
            <li className={`${!showIndividual ? "block" : "hidden" }`}>
                <a href="/individual"
                    onClick={() => dispatch({
                        type: "GO_TO_INDIVIDUAL"
                    })}
                    className="block p-2 text-2xl text-white hover:bg-[#43b552] xl:hover:bg-transparent xl:hover:text-white xl:text-white link link-underline link-underline-white xl:py-3 xl:mt-[6px]">
                    <p>Індивідуальний дизайн</p>
                </a>
            </li>
            <li className={`${!showShoppers ? "block" : "hidden"}`}>
                <a href="/shoppers"
                    onClick={() => dispatch({
                        type: "GO_TO_SHOPPERS"
                    })}
                    className="block p-2 text-2xl text-white hover:bg-[#43b552] xl:hover:bg-transparent xl:hover:text-white xl:text-white link link-underline link-underline-white xl:py-3 xl:mt-[6px]">
                    <p>В наявності</p>
                </a>
            </li>
            <li className={`${!showPins ? "block" : "hidden"}`}>
                <a href="/pins"
                    onClick={() => dispatch({
                        type: "GO_TO_PINS"
                    })}
                    className="block p-2 text-2xl text-white hover:bg-[#43b552] xl:hover:bg-transparent xl:hover:text-white xl:text-white link link-underline link-underline-white xl:py-3 xl:mt-[6px] rounded-bl-lg xl:rounded-none" >
                    <p>Піни</p>
                </a>
            </li>
        </ul>
    );
}