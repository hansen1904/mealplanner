import { LogoContainer , CompanyName, Image } from './logo.module.js'
import logo from './logo.png';

const Logo: React.FC<{}> = () => {
    return(
        <LogoContainer>
            <Image src={logo} />
            <CompanyName>Meal Planner</CompanyName>
        </LogoContainer>
    )
}

export default Logo