import { AvatarContainer, NameBox, Name, Role, ProfilImage } from './avatarBar.module' 

const AvatarBar: React.FC<{}> = () => {
    return(
        <AvatarContainer>
            <ProfilImage>M</ProfilImage>
            <NameBox>
                <Name>Magnus Hansen</Name>
                <Role>Admin</Role>
            </NameBox>
        </AvatarContainer>
    )
}

export default AvatarBar