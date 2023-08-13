import { IconGauge, IconNotes } from "@tabler/icons-react"
import { BsUiChecks } from "react-icons/bs"
import { FaWpforms } from "react-icons/fa"
import { MdOutlineAdminPanelSettings } from "react-icons/md"
import { TbUsers } from "react-icons/tb"

export const projectJson: any = {
  health: {
    documentTitle: 'health',
    projectTitle: 'health',
    navMenu: [
      { label: 'Home', icon: IconGauge, link: '/home' },
      { label: 'Admin', icon: IconGauge, link: '/admin' },
      { label: 'Doctor', icon: IconGauge, link: '/doctor' },
      { label: 'Patient', icon: IconGauge, link: '/patient' },
      // {
      //   label: 'Sourcing',
      //   icon: IconNotes,
      //   initiallyOpened: true,
      //   links: [
      //     { label: 'List', link: '/' },
      //     { label: 'Strategic', link: '/strategic' },
      //     { label: 'Supplier Quotation', link: '/supplierQuotation' },
      //     { label: 'Employee', link: '/employee' },
      //     { label: 'Banner', link: '/banner' },
      //     { label: 'Notification', link: '/notification' },
      //     { label: 'Webservice Detail', link: '/webserviceDetail' },
      //     { label: 'Client', link: '/client' },
      //     { label: 'Contact', link: '/contact' },
      //     { label: 'Project', link: '/sourcingProjectList' },
      //     {/* ## inceptor code block placeholder for sourcing ## */ }
      //   ],
      // }
    ]
  }
}