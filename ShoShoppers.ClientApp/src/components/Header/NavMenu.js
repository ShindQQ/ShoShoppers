import { Nav } from './Nav';
import { Cart } from '../Cart/Cart';
import { useEffect } from 'react';
import { CartState } from '../../context/Context';

export const NavMenu = () => {
    const {
        dispatch,
    } = CartState();

    useEffect(() => {
            dispatch({ type: "GO_TO_MAIN" })
    }, [dispatch]);

    return (
        <header className="relative bg-[#3ba144] text-white sticky top-0 w-full py-2 xl:py-0 px-4 lg:px-6 z-50 shadow-xl">
            <div className="flex items-center justify-between">
                <div className="flex w-auto order-first grow basis-0">
                    <a href="/" className="flex items-center text-3xl font-semibold whitespace-nowrap select-none drop-shadow-xl">
                        <p className="drop-shadow-lg">Sho?Shoppers!</p>
                    </a>
                </div>
                <Nav />
                <div className="flex w-auto order-2 xl:order-last items-center grow basis-28 xl:basis-0 justify-start xl:justify-end">
                    <Cart stylecss="hidden xl:flex" />
                </div>
            </div>
        </header>
    );
}
