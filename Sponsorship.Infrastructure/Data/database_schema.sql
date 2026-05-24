--
-- PostgreSQL database dump
--

\restrict Xt39HVobllugFcXFxoyx30kaHrXPIeUGpWRHmVgccjTG7bjPt9pz3otSI0Rd7Cg

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2026-05-24 19:37:56

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 225 (class 1259 OID 16542)
-- Name: app_users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.app_users (
    user_id uuid DEFAULT gen_random_uuid() NOT NULL,
    email character varying(250) NOT NULL,
    first_name character varying(100) NOT NULL,
    last_name character varying(100) NOT NULL,
    password_hash character varying(500),
    pass_set_on timestamp without time zone,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    is_active boolean NOT NULL,
    role_id integer
);


ALTER TABLE public.app_users OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16507)
-- Name: departments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.departments (
    dep_code character(3) NOT NULL,
    dep_name character varying(100) NOT NULL,
    description character varying(250),
    is_active boolean DEFAULT true
);


ALTER TABLE public.departments OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16461)
-- Name: sponsorship_requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sponsorship_requests (
    sponsorship_id uuid DEFAULT gen_random_uuid() NOT NULL,
    request_title character varying(150) NOT NULL,
    requestor_name character varying(150) NOT NULL,
    department character(3) NOT NULL,
    sponsorship_type character(3) NOT NULL,
    event_organisation_name character varying(250) NOT NULL,
    event_date date NOT NULL,
    requested_amount numeric(18,2) NOT NULL,
    purpose text CONSTRAINT sponsorship_requests_purpose_justification_not_null NOT NULL,
    expected_business_benefit text,
    remarks text,
    status_code character(3) DEFAULT 'PEN'::bpchar CONSTRAINT sponsorship_requests_status_not_null NOT NULL,
    created_at timestamp with time zone DEFAULT now() NOT NULL,
    updated_at timestamp with time zone,
    created_by uuid,
    updated_by uuid
);


ALTER TABLE public.sponsorship_requests OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16499)
-- Name: sponsorship_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sponsorship_types (
    type_code character(3) NOT NULL,
    type_name character varying(100) NOT NULL,
    description character varying(250),
    is_active boolean DEFAULT true
);


ALTER TABLE public.sponsorship_types OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16455)
-- Name: user_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_roles (
    role_id integer NOT NULL,
    role_name character varying(50),
    description character varying(250),
    is_active boolean
);


ALTER TABLE public.user_roles OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16530)
-- Name: workflow_histories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.workflow_histories (
    workflow_id uuid DEFAULT gen_random_uuid() NOT NULL,
    sponsorship_id uuid CONSTRAINT workflow_histories_request_id_not_null NOT NULL,
    notes text,
    action_by uuid NOT NULL,
    action_date timestamp without time zone DEFAULT now()
);


ALTER TABLE public.workflow_histories OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16482)
-- Name: workflow_status; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.workflow_status (
    status_code character(3) NOT NULL,
    status_name character varying(50) NOT NULL
);


ALTER TABLE public.workflow_status OWNER TO postgres;

--
-- TOC entry 4897 (class 2606 OID 16515)
-- Name: departments departments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.departments
    ADD CONSTRAINT departments_pkey PRIMARY KEY (dep_code);


--
-- TOC entry 4901 (class 2606 OID 16555)
-- Name: app_users pk_app_users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.app_users
    ADD CONSTRAINT pk_app_users PRIMARY KEY (user_id);


--
-- TOC entry 4891 (class 2606 OID 16481)
-- Name: sponsorship_requests sponsorship_requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sponsorship_requests
    ADD CONSTRAINT sponsorship_requests_pkey PRIMARY KEY (sponsorship_id);


--
-- TOC entry 4895 (class 2606 OID 16506)
-- Name: sponsorship_types sponsorship_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sponsorship_types
    ADD CONSTRAINT sponsorship_type_pkey PRIMARY KEY (type_code);


--
-- TOC entry 4889 (class 2606 OID 16460)
-- Name: user_roles user_roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_pkey PRIMARY KEY (role_id);


--
-- TOC entry 4899 (class 2606 OID 16541)
-- Name: workflow_histories workflow_histories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workflow_histories
    ADD CONSTRAINT workflow_histories_pkey PRIMARY KEY (workflow_id);


--
-- TOC entry 4893 (class 2606 OID 16488)
-- Name: workflow_status workflow_status_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workflow_status
    ADD CONSTRAINT workflow_status_pkey PRIMARY KEY (status_code);


-- Completed on 2026-05-24 19:37:56

--
-- PostgreSQL database dump complete
--

\unrestrict Xt39HVobllugFcXFxoyx30kaHrXPIeUGpWRHmVgccjTG7bjPt9pz3otSI0Rd7Cg

