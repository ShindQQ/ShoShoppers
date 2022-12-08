import { useState, useRef } from 'react';
import { Links } from './Links';
import { Cart } from '../Cart/Cart';
import { BurgerMenu } from './BurgerMenu';
import { useOnClickOutside } from '../ClickOutside/useOnClickOutside';

export const Nav = () => {
    const [showMenu, setShowMenu] = useState(false);
    const ref = useRef();
    useOnClickOutside(ref, () => setShowMenu(false));

    return (
        <nav ref={ref} className="w-auto flex order-last xl:order-2 my-auto grow-0 basis-0 xl:basis-auto xl:grow justify-end xl:justify-center">
            <div className="hidden xl:flex">
                <Links />
            </div>
            <div className={`absolute top-10 right-0 bg-[#3ba144] border-b-1 border-gray-300 rounded-bl-lg shadow-xl mt-5 z-50 transition-all duration-300 origin-top-right ${showMenu ? " scale-100" : "scale-0"}`}>
                <Links />
            </div>
            <div className="xl:hidden items-center flex justify-center">
                <Cart stylecss="flex xl:hidden" />
                <BurgerMenu setState={setShowMenu} state={showMenu} />  
            </div>
        </nav>
    );
}