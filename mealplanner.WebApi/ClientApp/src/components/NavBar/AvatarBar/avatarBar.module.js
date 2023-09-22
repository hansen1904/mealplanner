import { Avatar } from '@mui/material'
import styled from 'styled-components'

export const AvatarContainer = styled.div`
    clear: both;
    padding: 20px;
    background-color: rgba(0, 0, 0, 0.04);
    margin: 20px;
    box-sizing: border-box;
    border-radius: 8px;
`


export const NameBox = styled.div`
    float: left;
    padding-left: 15px;
`


export const Name = styled.span`
    display: block;
    font-weight: bold;
`

export const Role = styled.span`
    display: block;
    opacity: 0.6;
`

export const ProfilImage = styled(Avatar)`
    float: left;
`